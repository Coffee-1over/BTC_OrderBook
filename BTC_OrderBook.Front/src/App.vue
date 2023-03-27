<template>
  <div class="component">
    <highcharts :options="chartOptions" class="chart" />

    <div>
      <v-select v-model="selectedCurrencyPair" :options="currenciesPairs">
        <template #selected-option="option">
          <div>
            <span>{{ option.view }}</span>
          </div>
        </template>

        <template #option="option">
          {{ option.view }}
        </template>
      </v-select>
    </div>
  </div>
</template>

<script>
import { Chart } from 'highcharts-vue'
import { ref, defineComponent, watch, onMounted } from 'vue'
import { getOrderBookAsync, getOrderBookCurreciesPairsAsync } from './api/orderBook'
import exportingInit from 'highcharts/modules/exporting'

export default defineComponent({
  components: {
    highcharts: Chart
  },
  setup() {
    const selectedCurrencyPair = ref({})
    const currenciesPairs = ref([])
    const staticText = ' Market Depth'

    const chartOptions = ref({
      chart: {
        type: 'area',
        zoomType: 'xy'
      },
      title: {
        text: `BTC-EUR Market Depth`
      },
      xAxis: {
        minPadding: 0,
        maxPadding: 0,
        max: 700000,
        title: {
          text: 'Price'
        }
      },
      yAxis: [
        {
          lineWidth: 1,
          gridLineWidth: 1,
          title: null,
          tickWidth: 1,
          tickLength: 5,
          tickPosition: 'inside',
          labels: {
            align: 'left',
            x: 8
          },
          max: 150
        },
        {
          opposite: true,
          linkedTo: 0,
          lineWidth: 1,
          gridLineWidth: 0,
          title: null,
          tickWidth: 1,
          tickLength: 5,
          tickPosition: 'inside',
          labels: {
            align: 'right',
            x: -8
          }
        }
      ],
      legend: {
        enabled: false
      },

      tooltip: {
        headerFormat: '<span style="font-size=10px;">Price: {point.key}</span><br/>',
        valueDecimals: 2
      },
      series: [
        {
          name: 'Asks',
          data: [],
          color: '#fc5857'
        },
        {
          name: 'Bids',
          data: [],
          color: '#7CFC00'
        }
      ]
    })
    onMounted(async () => {
      currenciesPairs.value = await getOrderBookCurreciesPairsAsync()
      selectedCurrencyPair.value = currenciesPairs.value[0]

      await drawChartAsync()
      setInterval(drawChartAsync, 5000)
    })

    async function drawChartAsync() {
      if (selectedCurrencyPair.value.value) {
        const response = await getOrderBookAsync(selectedCurrencyPair.value.value)
        chartOptions.value.title.text = selectedCurrencyPair.value.view + staticText
        chartOptions.value.series[1].data = response.bids
        chartOptions.value.series[0].data = response.asks
      }
    }

    watch(() => selectedCurrencyPair.value, drawChartAsync)

    return { chartOptions, currenciesPairs, selectedCurrencyPair }
  }
})
</script>

<style scoped langs="css">
.component {
  display: grid;
  place-items: center;
  width: 100%;
  height: 100vh;
}
.chart {
  max-width: 2000px;
  width: 100%;
  height: 700px;
}
</style>
