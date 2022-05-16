const select = document.querySelector('select');
const allLang = ['en', 'ru'];

const langArr = {
    "WelcomeText": {
        "en": "Welcome to ICollections!",
        "ru": "Добро пожаловать на ICollections!",
    },
    "Login": {
        "en": "Login",
        "ru": "Войти",
    },
    "Register": {
        "en": "Register",
        "ru": "Зарегестрироваться",
    },
    "Profile": {
        "en": "Profile",
        "ru": "Профиль",
    },
    "Logout": {
        "en": "Logout",
        "ru": "Выйти",
    },
    "Collections": {
        "en": "Collections",
        "ru": "Колекции",
    },
    "CreateCollection": {
        "en": "Create collection",
        "ru": "Создать коллекцию",
    },
    "About": {
        "en": "About",
        "ru": "Обо мне",
    },
    "DontHaveAnAccount": {
        "en": "Don't have an account yet?",
        "ru": "Еще нет аккаунта?",
    },
    "HaveAnAccount": {
        "en": "Already have an account?",
        "ru": "Уже есть аккаунт?",
    },
    "Account": {
        "en": "Account",
        "ru": "Аккаунт",
    },
    "Theme": {
        "en": "Theme",
        "ru": "Тема",
    },
    "Description": {
        "en": "Description",
        "ru": "Описание",
    },
    "LastEditDate": {
        "en": "Last edit date",
        "ru": "Последнее изменение",
    },
    "Author": {
        "en": "Author",
        "ru": "Автор",
    },
    "Search": {
        "en": "Search",
        "ru": "Искать",
    },
    "FirstName": {
        "en": "First name",
        "ru": "Имя",
    },
    "LastName": {
        "en": "Last name",
        "ru": "Фамилия",
    },
    "MyCollections": {
        "en": "My collections",
        "ru": "Мои коллекции",
    },
    "UserName": {
        "en": "Username",
        "ru": "Никнейм",
    },
    "RegisterDate": {
        "en": "Register date",
        "ru": "Дата регистрации",
    },
    "Create": {
        "en": "Create",
        "ru": "Создать",
    },
    "Title": {
        "en": "Title",
        "ru": "Заголовок",
    },
    "SelectTheme": {
        "en": "Select theme of your Collection",
        "ru": "Выберите тему коллекции",
    },
    "Drag&Drop": {
        "en": "Drop file here or click to upload",
        "ru": "Перетащите файл или нажмите для загрузки",
    },
    "ThemeAlcohol": {
        "en": "Alcohol",
        "ru": "Алкоголь",
    },
    "ThemeBooks": {
        "en": "Books",
        "ru": "Книги",
    },
    "ThemeFilms": {
        "en": "Films",
        "ru": "Фильмы",
    },
    "Items": {
        "en": "Items",
        "ru": "Айтемы",
    },
    "Delete": {
        "en": "Delete",
        "ru": "Удалить",
    },
    "AddItem": {
        "en": "Add item",
        "ru": "Добавить айтем",
    },
    "FullName": {
        "en": "Nikita Korotki",
        "ru": "Никита Короткий",
    },
    "CourseProject": {
        "en": "This site was created how course project.",
        "ru": "Этот сайт был создан как курсовой проект.",
    },
    "AdminPanel": {
        "en": "Admin panel",
        "ru": "Панель управления",
    },
    "alcoholDate": {
        "en": "Add date of manufacture",
        "ru": "Добавить дату производства",
    },
    "alcoholBrand": {
        "en": "Add alcohol brand",
        "ru": "Добавить марку алкоголя",
    },
    "booksDate": {
        "en": "Add writing date",
        "ru": "Добавить дату написания",
    },
    "booksBrand": {
        "en": "Add books authors",
        "ru": "Добавить авторов книг",
    },
    "filmsDate": {
        "en": "Add release date to rental",
        "ru": "Добавить дату выпуска в прокат",
    },
    "filmsBrand": {
        "en": "Add studio name",
        "ru": "Добавить название студии",
    },
    "CollectionComments": {
        "en": "Add comments",
        "ru": "Добавить комментарии",
    },
    "Comments": {
        "en": "Comments",
        "ru": "Комментарии",
    },
    "alcoholItemDate": {
        "en": "Date of manufacture:",
        "ru": "Дата изготовления:",
    },
    "alcoholItemBrand": {
        "en": "Brand:",
        "ru": "Марка:",
    },
    "booksItemDate": {
        "en": "Date of writing:",
        "ru": "Дата написания:",
    },
    "booksItemBrand": {
        "en": "Book author:",
        "ru": "Автор книги:",
    },
    "filmsItemDate": {
        "en": "Release date:",
        "ru": "Дата премьеры:",
    },
    "filmsItemBrand": {
        "en": "Studio:",
        "ru": "Студия:",
    },
    "AddComment": {
        "en": "Add comment",
        "ru": "Прокоментировать",
    },
    "Block": {
        "en": "Block",
        "ru": "Заблокировать",
    },
    "Unblock": {
        "en": "Unblock",
        "ru": "Разблокировать",
    },
    "Status": {
        "en": "Status",
        "ru": "Статус",
    },
    "RegistrationDate": {
        "en": "Registration date",
        "ru": "Дата регистрации",
    },
    "RegistrationDate": {
        "en": "Registration date",
        "ru": "Дата регистрации",
    },
    "SelectAll": {
        "en": "Select All",
        "ru": "Выбрать все"
    },
    "Role": {
        "en": "Role",
        "ru": "Роль"
    },
    "Edit": {
        "en": "Edit",
        "ru": "Изменить"
    },
    
}

select.addEventListener('change',changeURLLanguage);

function changeURLLanguage() {
    let lang = select.value;
    localStorage.setItem('lang', lang);
    location.href = window.location.pathname + "#" + lang;
    location.reload();
}

function changeLanguage() {
    let lang = localStorage.getItem('lang');
    if (!allLang.includes(lang)) {
        location.href =  window.location.pathname + '#en';
        lang = "en";
        localStorage.setItem('lang', lang);
    }
    location.href = window.location.pathname + "#" + lang;
    select.value = lang;
    for (let key in langArr) {
        //let elem = document.querySelector(".lng-" + key);
        var elements = document.getElementsByClassName("lng-" + key);
        for (i = 0; i < elements.length; i++) {
            if (elements[i]) {
                elements[i].innerHTML = langArr[key][lang];
            }
        }
    }
}

function getCurrentLanguage() {
    return window.location.hash.substring(1);
}

changeLanguage();