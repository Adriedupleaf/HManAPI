
function checkBackgroundColor() {
    var cookieValue = "; " + document.cookie;
    var parts = cookieValue.split("; background-color=");
    if (parts.length === 2) {
        var color = parts.pop().split(";").shift();
        var body = document.getElementsByTagName("body")[0];
        if (color === "black") {
            body.style.backgroundColor = "black";
            body.style.color = "white";
        } else if (color === "white") {
            body.style.backgroundColor = "white";
            body.style.color = "black";
        }
    }
}
addEventListener("input", (event) => {
    var body = document.getElementsByTagName("body")[0];
    if (body.style.backgroundColor === "white") {
        body.style.backgroundColor = "black";
        body.style.color = "white";
        document.cookie = "background-color=black; expires=Fri, 31 Dec 9999 23:59:59 GMT";
    } else {
        body.style.backgroundColor = "white";
        body.style.color = "black";
        document.cookie = "background-color=white; expires=Fri, 31 Dec 9999 23:59:59 GMT";
    } })