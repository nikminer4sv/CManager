if (document.getElementById("likeButton").getAttribute("checked") == "true") {
    likeButton.classList.remove("btn-primary");
    likeButton.classList.add("btn-danger");
}
    

function SwitchLike() {
    let likeButton = document.getElementById("likeButton");
    let condition = likeButton.getAttribute("checked");
    if (condition === "true") {
        likeButton.classList.remove("btn-danger");
        likeButton.classList.add("btn-primary");
        likeButton.setAttribute("checked", "false");
    } else {
        likeButton.classList.remove("btn-primary");
        likeButton.classList.add("btn-danger");
        likeButton.setAttribute("checked", "true");
    }
}