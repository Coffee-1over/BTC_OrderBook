import { createApp } from 'vue'
import App from './App.vue'
import HighchartsVue from 'highcharts-vue'
import 'vue-select/dist/vue-select.css';
import './assets/base.scss';
import vSelect from 'vue-select';

const app = createApp(App);
app.use(HighchartsVue).component('v-select', vSelect).mount('#app');