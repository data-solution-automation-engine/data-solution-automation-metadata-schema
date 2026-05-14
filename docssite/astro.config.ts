import starlight from '@astrojs/starlight';
import { defineConfig } from 'astro/config';

export default defineConfig({
  site: 'https://data-solution-automation-engine.github.io',
  base: '/data-solution-automation-metadata-schema',
  outDir: 'dist',
  devToolbar: {
    enabled: false,
  },
  integrations: [
    starlight({
      title: 'Data Solution Automation Schema',
      description:
        'Generic metadata schema for data solution automation - an exchange format for data logistics generation metadata.',
      favicon: '/favicon.ico',
      logo: {
        src: './src/assets/logo.png',
        alt: 'Data Solution Automation Schema',
      },
      pagefind: false,
      social: [
        {
          icon: 'github',
          label: 'GitHub',
          href: 'https://github.com/data-solution-automation-engine/data-solution-automation-metadata-schema',
        },
      ],
      sidebar: [
        {
          label: 'Home',
          slug: '',
        },
        {
          label: 'Overview',
          autogenerate: { directory: 'overview' },
        },
        {
          label: 'Schema Reference',
          collapsed: true,
          autogenerate: { directory: 'reference' },
        },
        {
          label: 'Handlebars Helpers',
          collapsed: true,
          autogenerate: { directory: 'handlebars' },
        },
        {
          label: 'FAQ',
          collapsed: true,
          autogenerate: { directory: 'faq' },
        },
      ],
    }),
  ],
});
