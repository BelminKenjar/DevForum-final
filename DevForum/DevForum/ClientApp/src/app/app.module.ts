import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { ApiAuthorizationModule } from 'src/api-authorization/api-authorization.module';
import { AuthorizeGuard } from 'src/api-authorization/authorize.guard';
import { AuthorizeInterceptor } from 'src/api-authorization/authorize.interceptor';
import { ProfileComponent } from './profile/profile.component';
import { ProfileDetailsComponent } from './profile-details/profile-details.component';
import { ProfileStatsComponent } from './profile-stats/profile-stats.component';
import { NgxSpinnerModule } from 'ngx-spinner';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ProfilesComponent } from './profiles/profiles.component';
import { ProfileItemComponent } from './profile-item/profile-item.component';
import { PaginationComponent } from './pagination/pagination.component';
import { NewsComponent } from './news/news.component';
import { NewsItemComponent } from './news-item/news-item.component';
import { NewsFormComponent } from './news-form/news-form.component';
import { TopicComponent } from './topic/topic.component';
import { TopicItemComponent } from './topic-item/topic-item.component';
import { TopicFormComponent } from './topic-form/topic-form.component';
import { SearchComponent } from './search/search.component';
import { TopicDetailsComponent } from './topic-details/topic-details.component';
import { SubtopicItemComponent } from './subtopic-item/subtopic-item.component';
import { SubtopicComponent } from './subtopic/subtopic.component';
import { SubtopicFormComponent } from './subtopic-form/subtopic-form.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    ProfileComponent,
    ProfileDetailsComponent,
    ProfileStatsComponent,
    ProfilesComponent,
    ProfileItemComponent,
    PaginationComponent,
    NewsComponent,
    NewsItemComponent,
    NewsFormComponent,
    TopicComponent,
    TopicItemComponent,
    TopicFormComponent,
    SearchComponent,
    TopicDetailsComponent,
    SubtopicItemComponent,
    SubtopicComponent,
    SubtopicFormComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    NgbModule,
    NgxSpinnerModule,
    BrowserAnimationsModule,
    ApiAuthorizationModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'profile', component: ProfileComponent, canActivate: [AuthorizeGuard] },
      { path: 'users', component: ProfilesComponent },
      { path: 'news', component: NewsComponent },
      { path: 'topics', component: TopicComponent },
      { path: 'topics/:id', component: TopicDetailsComponent }
    ])
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: AuthorizeInterceptor, multi: true }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
