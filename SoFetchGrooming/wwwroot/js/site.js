// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

// Load A Random Dog fact when the page loads
document.addEventListener('DOMContentLoaded', function () {

    getRandomDogFact().then(data => {
        const dogFactsContainer = document.getElementById('dog-facts');
        dogFactsContainer.textContent = data.data[0].attributes.body;
    });

});


// We are using this API (https://dogapi.dog/docs/api-v2) to get a random dog fact
async function getRandomDogFact() {
    
    // Get the Random Dog Fact and await for a response
    let response = await fetch('https://dogapi.dog/api/v2/facts');
    console.log(response);

    // Check if the response is ok
    if (!response.ok) {
        alert("Could not retrieve a Fact please try again later");
        throw new Error(`HTTP error! status: ${response.status}`);
    }

    // Parse the response as JSON if the response is ok
    let data = await response.json();
    console.log(data);
    return data;
};
