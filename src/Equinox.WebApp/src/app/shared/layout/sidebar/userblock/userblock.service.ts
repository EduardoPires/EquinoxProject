<<<<<<< HEAD
<<<<<<< HEAD
import { Injectable } from "@angular/core";
=======
import { Injectable } from '@angular/core';
>>>>>>> fd1205c... Bug fix while creating new Db.
=======
import { Injectable } from "@angular/core";
>>>>>>> 86e6256... Daily commit

@Injectable()
export class UserblockService {
    public userBlockVisible: boolean;
    constructor() {
        // initially visible
        this.userBlockVisible  = true;
    }

    getVisibility() {
        return this.userBlockVisible;
    }

    setVisibility(stat = true) {
        this.userBlockVisible = stat;
    }

    toggleVisibility() {
        this.userBlockVisible = !this.userBlockVisible;
    }

}
