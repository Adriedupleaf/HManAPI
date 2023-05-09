
document.getElementById("toggle").addEventListener("click", (event) => {
        var element = document.getElementById("navbar");
        //create an if for find the class name of the element and change it to the other class name

    if (element.classList.contains("navbar-dark") && element.classList.contains("bg-dark")){
            element.className = "navbar navbar-expand-lg navbar-light bg-light";
        } else {
            element.className = "navbar navbar-expand-lg navbar-dark bg-dark";
        }
    });
