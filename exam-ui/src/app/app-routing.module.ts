import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { NotificationDetailComponent } from '../components/shared/notification/notification-detail/notification-detail.component'; // Import NotificationDetailComponent

const routes: Routes = [
    // ...existing routes...
    { path: 'notification-detail', component: NotificationDetailComponent }, // Add this route
    { path: '**', redirectTo: '' } // Redirect unknown routes to home or another default route
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule { }
