import { RouterModule, Routes } from "@angular/router";
import { ReservationListComponent } from "./reservation-list/reservation-list.component";
import { NgModule } from "@angular/core";

const routes: Routes = [
    { path: '', redirectTo: 'list', pathMatch: 'full' },
    { path: 'list', component: ReservationListComponent },
    { path: '**', redirectTo: 'list' }

];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule],
    declarations: []
})

export class ReservationsRoutingModule { }