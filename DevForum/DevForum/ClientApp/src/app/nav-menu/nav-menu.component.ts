import {Component, OnInit} from '@angular/core';
import {TranslateService} from '@ngx-translate/core';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent implements OnInit {
  isExpanded = false;
  lang = '';

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }
  constructor(private translateService: TranslateService) {

  }

  ngOnInit(): void {
    this.lang = localStorage.getItem('lang') || 'en';

  }

  ChangeLang(lang: any) {
    const selectedLanguage = lang.target.value;
    localStorage.setItem('lang', selectedLanguage);
    this.translateService.use(selectedLanguage);
  }
}
