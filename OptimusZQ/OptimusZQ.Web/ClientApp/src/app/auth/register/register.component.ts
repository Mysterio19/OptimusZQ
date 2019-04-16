import { Component } from '@angular/core';
import { UserService } from '../../_services/user.service';

@Component({
    selector: 'app-register',
    templateUrl: './register.component.html',
    styleUrls: ['./register.component.scss']
})
/** register component*/
export class RegisterComponent {
  model: any = {};

    /** register ctor */
    constructor() {

    }
}
