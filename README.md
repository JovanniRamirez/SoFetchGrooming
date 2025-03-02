# SoFetchGrooming

## Project Members
[Jovanni Ramirez](https://github.com/JovanniRamirez)

[Adrian Huerta](https://github.com/Azael-Hue)

## What is this Project about?
the main idea behind the this project is a website for a Pet grooming service in which users can make appointments for their pets as long as they are signed in and can buy some care products as well.

## What APIs are we using?
We are intending to use some API among them them:
 - [Cat Facts API](https://alexwohlbruck.github.io/cat-facts/)
 - [Dog Facts API](https://dukengn.github.io/Dog-facts-API/)
 - [Google Maps API](https://developers.google.com/maps/documentation/embed/get-started)

Here is an example of the Google Maps API being tested on the site:

![image](https://github.com/user-attachments/assets/2a152e6e-d6db-4cfe-a1e0-0924d8c49e78)

## Will this be updated?
This README.md file will be updated alongside the project

## Pagination Implementation
I added a shared view for Pagination Navigation that is sharable for any view that requires pagination navigation links.
### Steps for implementing Pagination
 - Download X.PagedList.Mvc from NuGet Package Manager
 - [Wiki for X.PagedList.Mvc](https://github.com/dncuug/X.PagedList/wiki/X.PagedList)
 - Add @using X.PagedList.Mvc to your controller and view page to use the page variables
 - Pass the parameters pageNumber and pageSize to the view in a IPagedList<> object, or in my case, Return the paginated list of products to the view with page properties
 - I made a separate view for pagination that is sharable in the shared folder called _Pagination.chtml that is linked to the bottom of the view I want to use it on
 - In my case I added it to the bottom of Product.Index.chtml as: @Html.Partial("_Pagination", Model)
 - _Pagination accepts the list of model and connects the links of the pagination navigation to the first page, the last page, the previous page and the next page
 - I also managed it so the highlighted link stays in the middle of the 5 integer page links displayed if the highlighted link is any integer page not first or second or last or second to last
![image](SoFetchGroomingWebsite\\SoFetchGrooming\\SoFetchGrooming\\DocsAndImages\\ProductPageNav1.png)
![image](DocsAndImages\ProductPageNav4.png)
![image](DocsAndImages\ProductPageNav76.png)
![image](DocsAndImages\ProductPageNav77.png)

## Helpful Links
[Bootstrap Documentation](https://getbootstrap.com/docs/4.1/getting-started/introduction/)

[Public API list](https://github.com/public-apis/public-apis)

