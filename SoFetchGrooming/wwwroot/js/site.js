// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.



// Load A Random Dog and Cat fact when the page loads and
// display them in the respective sections as a list item
document.addEventListener('DOMContentLoaded', function () {

    getRandomDogFact().then(data => {
        const dogFactsContainer = document.getElementById('dog-facts');

        let ul = document.createElement("ul");
        let li = document.createElement("li");

        li.textContent = data.data[0].attributes.body;
        ul.appendChild(li);

        dogFactsContainer.appendChild(ul);
    });

    getRandomCatFact().then(data => {
        const catFactsContainer = document.getElementById('cat-facts');

        let ul = document.createElement("ul");
        let li = document.createElement("li");

        li.textContent = data.fact;
        ul.appendChild(li);

        catFactsContainer.appendChild(ul);
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

// We are using this API (https://catfact.ninja/) to get a random cat fact
async function getRandomCatFact() {

    // Get the Random Cat Fact and await for a response
    let response = await fetch('https://catfact.ninja/fact');
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