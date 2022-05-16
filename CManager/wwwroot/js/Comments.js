let connection = new signalR.HubConnectionBuilder().withUrl("/chat").build();

document.getElementById("sendButton").disabled = true;

connection.on("ReceiveComment", function (user, comment, date) {
    let newComment = document.getElementById("newComment");

    let commentBody = document.createElement("div");
    commentBody.className = "card text-dark bg-light mb-3";
    newComment.prepend(commentBody);
    
    let author = document.createElement("div");
    author.className = "card-header fw-bold";
    author.textContent = `Author: ${user}`;
    commentBody.appendChild(author);
    
    let contentBody = document.createElement("div");
    contentBody.className = "card-body";
    commentBody.appendChild(contentBody);

    let content = document.createElement("p");
    content.className = "card-text";
    content.textContent = `${comment}`;
    contentBody.appendChild(content);
    
    let separator = document.createElement("hr")
    contentBody.appendChild(separator);
    
    let postDate = document.createElement("p");
    postDate.className = "card-text";
    postDate.textContent = `${date}`;
    contentBody.appendChild(postDate);
    
    
});

connection.start().then(function () {
    document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("sendButton").addEventListener("click", function (event) {
    let comment = document.getElementById("commentToSend").value;
    let itemId = document.getElementById("itemId").value;
    connection.invoke("SendComment", comment, itemId).catch(function (err) {
        return console.error(err.toString());
    });
    document.getElementById("commentToSend").value = "";
    event.preventDefault();
});