/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { TranslateService, TranslateModule, TranslateLoader } from '@ngx-translate/core';
import { HttpClientModule, HttpClient } from '@angular/common/http';

import { TranslatorService } from './translator.service';
import { createTranslateLoader } from '../../app.module';

describe('Service: Translator', () => {
    beforeEach(() => {
        TestBed.configureTestingModule({
            imports: [
                HttpClientModule,
                TranslateModule.forRoot({
                    loader: {
                        provide: TranslateLoader,
                        useFactory: (createTranslateLoader),
                        deps: [HttpClient]
                    }
                })
            ],
            providers: [TranslatorService]
        });
    });

    it('should ...', inject([TranslatorService], (service: TranslatorService) => {
        expect(service).toBeTruthy();
    }));
});
