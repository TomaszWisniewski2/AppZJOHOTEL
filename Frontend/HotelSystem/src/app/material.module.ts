// import { NGX_MAT_DATE_FORMATS } from '@angular-material-components/datetime-picker';
import { CommonModule } from '@angular/common';
import { LOCALE_ID, NgModule } from '@angular/core';
// import { MatButtonModule } from '@angular/material/button';
// import { MatButtonToggleModule } from '@angular/material/button-toggle';
// import { MatCardModule } from '@angular/material/card';
// import { MatCheckboxModule } from '@angular/material/checkbox';
// import { MatDatepickerModule } from '@angular/material/datepicker';
// import { MatIconModule } from '@angular/material/icon';
// import { MatInputModule } from '@angular/material/input';
// import { MatListModule } from '@angular/material/list';
// import { MatPaginatorModule } from '@angular/material/paginator';
// import { MatProgressBarModule } from '@angular/material/progress-bar';
// import { MatSelectModule } from '@angular/material/select';
// import { MatSidenavModule } from '@angular/material/sidenav';
// import { MatSnackBarModule } from '@angular/material/snack-bar';
// import { MatSortModule } from '@angular/material/sort';
// import { MatTableModule } from '@angular/material/table';
// import { MatTooltipModule } from '@angular/material/tooltip';
// import { NgxMatDatetimePickerModule } from '@angular-material-components/datetime-picker';
// import { NgxMatTimepickerModule } from '@angular-material-components/datetime-picker';
// import { DateAdapter, MAT_DATE_FORMATS, MAT_DATE_LOCALE } from '@angular/material/core';
// import { MAT_MOMENT_DATE_ADAPTER_OPTIONS, MomentDateAdapter } from "@angular/material-moment-adapter";


// moment.fn.toJSON = function () {
//   return this.format();
// };
@NgModule({
    declarations: [],
    imports: [
        CommonModule,
    ],
    exports: [

    ],
    providers: [
        { provide: LOCALE_ID, useValue: 'pl' },
        // { provide: MAT_DATE_LOCALE, useValue: 'pl' },
        // { provide: MAT_MOMENT_DATE_ADAPTER_OPTIONS, useValue: { useUtc: false, strict: true } },
        // {
        //   provide: MAT_DATE_FORMATS,
        //   useValue: {
        //     parse: {
        //       dateInput: ["DD.MM.YYYY"],
        //     },
        //     display: {
        //       dateInput: "DD.MM.YYYY",
        //       monthYearLabel: "MMM YYYY",
        //       dateA11yLabel: "LL",
        //       monthYearA11yLabel: "MMMM YYYY",
        //     },
        //   },
        // },
        // {
        //   provide: DateAdapter,
        //   useClass: MomentDateAdapter,
        //   deps: [MAT_DATE_LOCALE, MAT_MOMENT_DATE_ADAPTER_OPTIONS],
        // },
        // {
        //   provide: NGX_MAT_DATE_FORMATS,
        //   useValue: {
        //     parse: {
        //       dateInput: ["DD.MM.YYYY, HH:mm"],
        //     },
        //     display: {
        //       dateInput: "DD.MM.YYYY, HH:mm",
        //       monthYearLabel: "MMM YYYY",
        //       dateA11yLabel: "LL",
        //       monthYearA11yLabel: "MMMM YYYY",
        //     },
        //   }
        // },

    ]
})
export class MaterialModule { }


