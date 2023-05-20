import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { RouterModule } from "@angular/router";
import { MaterialModule } from "./material.module";



@NgModule({
    declarations: [

    ],
    imports: [
        MaterialModule,
        FormsModule,
        ReactiveFormsModule,
        CommonModule,
        RouterModule
    ],
    exports: [
        MaterialModule,
        CommonModule,
        FormsModule,
        ReactiveFormsModule,

    ],
})

export class SharedModule { }