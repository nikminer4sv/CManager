function getElementsWithAttribute(attribute) {
    var matchingElements = [];
    var allElements = document.getElementsByTagName('*');
    for (var i = 0, n = allElements.length; i < n; i++) 
        if (allElements[i].getAttribute(attribute) !== null)
            matchingElements.push(allElements[i]);
    return matchingElements;
}

let changeThemeButton = document.getElementById('changeTheme');

changeThemeButton.addEventListener('click', function () {
    changeTheme();
});

function SetTheme(theme) {

    let elements = getElementsWithAttribute('theme-dark');
    if (theme === 'light') {
        for (i = 0; i < elements.length; i++) {
            elements[i].classList.remove(...elements[i].getAttribute("theme-dark").split(" "));
            elements[i].classList.add(...elements[i].getAttribute("theme-light").split(" "));
        }
    } else {
        for (i = 0; i < elements.length; i++) {
            elements[i].classList.remove(...elements[i].getAttribute("theme-light").split(" "));
            elements[i].classList.add(...elements[i].getAttribute("theme-dark").split(" "));
        }
    }
    
}

function changeTheme() {
    
    if (localStorage.getItem("theme") === "light") {
        SetTheme("dark");
        localStorage.setItem("theme", "dark");
    } else {
        SetTheme("light");
        localStorage.setItem("theme", "light");
    }
    
}

let activeTheme = localStorage.getItem('theme'); 

if (activeTheme === null || activeTheme === 'dark') { 
    SetTheme("dark");
}