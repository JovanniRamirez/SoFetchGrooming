using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoFetchGrooming.Data;
using SoFetchGrooming.Models;
using X.PagedList.Extensions;

namespace SoFetchGrooming.Controllers
{
    /// <summary>
    /// ProductsController is the controller for the products in the system
    /// </summary>
    [Authorize(Roles = "Admin")] // Only users with the Admin role can access this action
    public class ProductsController : Controller
    {
        /// <summary>
        /// ApplicationDbContext is the database context for the application
        /// </summary>
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// ProductsController constructor to initialize the database context
        /// </summary>
        /// <param name="context"></param>
        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Products
        /// <summary>
        /// Index is the action that returns the view that shows the list of products
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous] // Allow anonymous users to access this action
        public async Task<IActionResult> Index(int? page)
        {
            var products = await _context.Products
                .Include(p => p.ProductImages) // Include the related product images
                .OrderBy(p => p.ProductId).ToListAsync(); // Order the products by the product id
            int pageSize = 12; // Set the page size to 12
            int pageNumber = (page ?? 1); // Set the page number to the page number or 1
                                          // Return the products to the view using ToPagedList to paginate the products
            return View(products.ToPagedList(pageNumber, pageSize));
        }

        // GET: Products/Details
        /// <summary>
        /// Details is the action that returns the view that shows the details of the product
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [AllowAnonymous] // Allow anonymous users to access this action
        public async Task<IActionResult> Details(int? id, int? page)
        {
            if (id == null) // Check if the id is null
            {
                return NotFound();  // Return NotFound if the id is null
            }
            // Find the product with the given id, include the ProductImages
            var product = await _context.Products
                .Include(p => p.ProductImages) // Include the ProductImages
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["currentPage"] = page ?? 1; // Store the current page in the ViewData
                                                 // Return the product to the view
            return View(product);
        }

        // GET: Products/Create
        /// <summary>
        /// Create is the action that returns the view that creates a new product
        /// </summary>
        /// <returns></returns>
        public IActionResult Create()
        {
            return View();  //Return the view that creates a product
        }

        // POST: Products/Create
        // To protect from over posting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Create is the action that creates a new product
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductName,ProductDescription,ProductPrice,ProductQuantity,ProductImages")] Product product)
        {
            if (ModelState.IsValid)
            {
                // Create a new product and add it to the context
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Products/Edit
        /// <summary>
        /// Edit is the action that returns the view that edits the product
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Edit(int? id)
        {
            // Check if the id is null
            if (id == null)
            {
                return NotFound();
            }
            // Find the product with the given id
            var product = await _context.Products
                .Include(p => p.ProductImages)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from over posting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Edit is the action that edits the product
        /// </summary>
        /// <param name="id"></param>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductId,ProductName,ProductDescription,ProductPrice,ProductQuantity,ProductImages")] Product product)
        {
            if (id != product.ProductId)
            {
                return NotFound(); // If the id does not match the product id, return NotFound
            }
            // Check if the model state is valid
            if (ModelState.IsValid)
            {
                try
                {
                    // Get the existing product from the database, including the ProductImages
                    var existingProduct = await _context.Products
                        .Include(p => p.ProductImages)
                        .FirstOrDefaultAsync(p => p.ProductId == id);

                    // If the product does not exist, return NotFound
                    if (existingProduct == null) {
                        return NotFound();
                    }

                    // Update the existing product's properties manually
                    existingProduct.ProductName = product.ProductName;
                    existingProduct.ProductDescription = product.ProductDescription;
                    existingProduct.ProductPrice = product.ProductPrice;
                    existingProduct.ProductQuantity = product.ProductQuantity;

                    // Handle ProductImages (update/add/delete as necessary)
                    // Get the new list of image URLs from the product being edited
                    var newImageUrls = product.ProductImages.Select(pi => pi.ImageUrl).ToList();

                    // Remove images that are not in the new list
                    var imagesToRemove = existingProduct.ProductImages
                        .Where(pi => !newImageUrls.Contains(pi.ImageUrl)) // Check if the image is not in the new list
                        .ToList();
                    foreach (var image in imagesToRemove)
                    {
                        _context.ProductImages.Remove(image); // Remove the image from the database
                    }
                    // Add or update images from the form
                    foreach (var productImage in product.ProductImages)
                    {
                        // Check if the image already exists in the existing product
                        var existingImage = existingProduct.ProductImages
                            .FirstOrDefault(pi => pi.ImageUrl == productImage.ImageUrl);

                        if (existingImage == null) // If the image does not exist, add it
                        {
                            existingProduct.ProductImages.Add(new ProductImage
                            {
                                ImageUrl = productImage.ImageUrl,
                                ProductId = existingProduct.ProductId // Ensure ProductId is set for the new image
                            });
                        }
                        else // If the image exists, update it
                        {
                            existingImage.ImageUrl = productImage.ImageUrl; // Update existing images
                        }
                    }
                    // Save the changes to the database
                    await _context.SaveChangesAsync();
                }
                // Check if the product was not found
                catch (DbUpdateConcurrencyException)
                {
                    // If the product does not exist, return NotFound
                    if (!ProductExistsById(product.ProductId))
                    {
                        // Return NotFound if the product does not exist
                        return NotFound();
                    }
                    // Rethrow the exception if the product exists and there was a concurrency issue
                    else
                    {
                        throw;
                    }
                }
                // Redirect to the index action after saving the changes
                return RedirectToAction(nameof(Index));
            }
            // Return the product to the view if the model state is not valid with the validation errors
            return View(product);
        }

        private bool ProductExistsById(int id)
        {
            return _context.Products.Any(e => e.ProductId == id);
        }

        // GET: Products/Delete
        /// <summary>
        /// Delete is the action that returns the view that deletes the product
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Delete(int? id)
        {
            // Check if the id is null
            if (id == null)
            {
                return NotFound();
            }
            // Find the product with the given id
            var product = await _context.Products
                        .Include(p => p.ProductImages)
                        .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }
            // Return the product to the view
            return View(product);
        }

        // POST: Products/Delete
        /// <summary>
        /// DeleteConfirmed is the action that deletes the product from the database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            // Find the product with the given id
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
            }
            // Save the changes to the database
            await _context.SaveChangesAsync();
            // Redirect to the index action
            return RedirectToAction(nameof(Index));
        }

        // Check if the product exists
        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.ProductId == id);
        }
    }
}
