
const Home = {
    text: "Home",
    link: "/home",
    icon: "icon-home"
};

const Settings = {
    text: "User Settings",
    link: "/user",
    icon: "icon-settings",
    submenu: [
        {
            text: "Profile",
            link: "/user/profile"
        }
    ]
};

const headingMain = {
    text: "Main Navigation",
    heading: true
};

export const menu = [
    headingMain,
    Home,
    Settings
];
