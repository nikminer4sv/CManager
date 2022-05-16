function blockCheckedContacts() {
    let objectsToBlock = document.getElementsByClassName("user-checkbox")
    let contactIds = [];
    for (let i = 0; i < objectsToBlock.length; i++) {
        let objectToDelete = objectsToBlock[i];
        if (objectToDelete.checked)
            contactIds.push(objectsToBlock[i].getAttribute("name"));
    }
    if (contactIds.length > 0) {
        let requestString = "";
        for (let i = 0; i < contactIds.length - 1; i++) {
            requestString += "Ids[" + i + "]=" + contactIds[i] + "&"
        }
        requestString += "Ids[" + (contactIds.length - 1) + "]=" + contactIds[contactIds.length - 1] + "";

        window.location.replace("/AdminPanel/block?" + requestString);
    }
}

function unblockCheckedContacts() {
    let objectsToUnblock = document.getElementsByClassName("user-checkbox")
    let contactIds = [];
    for (let i = 0; i < objectsToUnblock.length; i++) {
        let objectToDelete = objectsToUnblock[i];
        if (objectToDelete.checked)
            contactIds.push(objectsToUnblock[i].getAttribute("name"));
    }

    if (contactIds.length > 0) {
        let requestString = "";
        for (let i = 0; i < contactIds.length - 1; i++)
            requestString += "Ids[" + i + "]=" + contactIds[i] + "&"
        
        requestString += "Ids[" + (contactIds.length - 1) + "]=" + contactIds[contactIds.length - 1] + "";
        window.location.replace("/AdminPanel/unblock?" + requestString);
    }
}

function deleteCheckedContacts() {
    console.log("GG");
    let objectsToDelete = document.getElementsByClassName("user-checkbox");
    let contactIds = [];
    for (let i = 0; i < objectsToDelete.length; i++) {
        let objectToDelete = objectsToDelete[i];
        if (objectToDelete.checked)
            contactIds.push(objectsToDelete[i].getAttribute("name"));
    }
    if (contactIds.length > 0) {
        let requestString = "";
        for (let i = 0; i < contactIds.length - 1; i++) {
            requestString += "Ids[" + i + "]=" + contactIds[i] + "&"
        }
        requestString += "Ids[" + (contactIds.length - 1) + "]=" + contactIds[contactIds.length - 1] + "";

        window.location.replace("/AdminPanel/delete?" + requestString);
    }

}
