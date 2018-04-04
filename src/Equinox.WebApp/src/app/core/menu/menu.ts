
const Home = {
    text: "Home",
<<<<<<< HEAD
<<<<<<< HEAD
    link: "/home",
=======
    link: "/panel/home",
>>>>>>> fd1205c... Bug fix while creating new Db.
=======
    link: "/home",
>>>>>>> 35c7771... daily commit
    icon: "icon-home"
};

const Settings = {
<<<<<<< HEAD
<<<<<<< HEAD
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
=======
    text: "Home",
    link: "/panel/home",
=======
    text: "User Settings",
<<<<<<< HEAD
    link: "/user-settings",
>>>>>>> 35c7771... daily commit
    icon: "icon-home"
<<<<<<< HEAD
}
>>>>>>> fd1205c... Bug fix while creating new Db.
=======
=======
    link: "/user",
    icon: "icon-settings",
    submenu: [
        {
            text: "Profile",
            link: "/user/profile"
        }
    ]
>>>>>>> 226bd07... Daily commit
};
>>>>>>> c0e4a03... adding some files

const headingMain = {
    text: "Main Navigation",
    heading: true
};

export const menu = [
    headingMain,
    Home,
    Settings
];
