import { NgModule } from "@angular/core";
import { SharedModule } from "../shared.module";
import { ReservationListComponent } from "./reservation-list/reservation-list.component";


@NgModule({
    declarations:
        [
            ReservationListComponent,
        ],
    imports: [
        SharedModule,
    ],
    exports: [],
})
export class ReservationsModule { }
