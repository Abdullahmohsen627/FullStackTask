import {
  ApplicationConfig,
  provideBrowserGlobalErrorListeners,
  provideZoneChangeDetection,
} from '@angular/core';
import { provideRouter } from '@angular/router';
import Aura from '@primeuix/themes/aura';
import { provideHttpClient, withInterceptors } from '@angular/common/http';
import { providePrimeNG } from 'primeng/config';
import { TooltipModule } from 'primeng/tooltip';
import { routes } from './app.routes';
import { loginInterceptor } from './Core/interceptors/login-interceptor';

export const appConfig: ApplicationConfig = {
  providers: [
    provideBrowserGlobalErrorListeners(),
    provideZoneChangeDetection({ eventCoalescing: true }),
    provideRouter(routes),
    provideHttpClient(withInterceptors([loginInterceptor])),
    TooltipModule,
    providePrimeNG({
      theme: {
        preset: Aura,
      },
    }),
  ],
};
