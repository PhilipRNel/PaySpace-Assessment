/** @type {import('tailwindcss').Config} */
module.exports = {
  content: ['./**/*{razor,html}'],
    theme: {
      fontFamily: {
            sans: ['Inter var', 'ui-sans-serif', 'system-ui'],
        },
        extend: {
            animation: {
                scales: 'scales 5s ease-in infinite',
                spin: 'spin 6s ease-in-out 1',
                autospin: 'spin 2s linear infinite',
            },
        },
    },
    variants: {
        animation: ['responsive', 'motion-safe', 'motion-reduce'],
    },
  plugins: [],
}