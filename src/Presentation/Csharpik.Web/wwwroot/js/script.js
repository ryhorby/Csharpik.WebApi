var path = window.location.pathname;

if (path == "/" || path.split("/")[1] == "Home") {
    document.querySelector("#Home").classList.add("current-page");
}
if (path.split("/")[1] == "Book") {
    document.querySelector("#Book").classList.add("current-page");
}
if (path.split("/")[1] == "Lesson") {
    document.querySelector("#Lesson").classList.add("current-page");
}