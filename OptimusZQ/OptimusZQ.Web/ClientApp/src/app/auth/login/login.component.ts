import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from '../../_services/authentication.service';
import { Router, ActivatedRoute } from '@angular/router';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
/** login component*/
export class LoginComponent implements OnInit {
  model: any = {};
  loading = false;
  returnUrl: string;

  /** login ctor */
  constructor(
    private router: Router,
    private authService: AuthenticationService
  ) { }


  ngOnInit() {
    // reset login status
    this.authService.logout();

  }

  login() {
    debugger
    this.loading = true;
    this.authService.login(this.model.login, this.model.password)
      .subscribe(
        data => {
          this.router.navigate([this.returnUrl]);
        },
        error => {
          this.loading = false;
        });
  }
}
