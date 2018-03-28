/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';

import { UserblockComponent } from './userblock.component';
import { UserblockService } from './userblock.service';

describe('Component: Userblock', () => {

    beforeEach(() => {
        TestBed.configureTestingModule({
            providers: [UserblockService]
        }).compileComponents();
    });

    it('should create an instance', async(inject([UserblockService], (userBlockService) => {
        let component = new UserblockComponent(userBlockService);
        expect(component).toBeTruthy();
    })));
});
