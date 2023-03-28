<template>
  <div class="component">
    <highcharts :options="chartOptions" class="chart" />

    <div>
      <v-select class="select_currencies" v-model="selectedCurrencyPair" :options="currenciesPairs">
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

    const chartTemplate = {
      chart: {
        type: 'area',
        zoomType: 'xy'
      },
      title: {
        text: 'BTC-EUR Market Depth'
      },
      xAxis: {
        min: null,
        max: null,
        minPadding: 0,
        maxPadding: 0,
        plotLines: [
          {
            color: '#888',
            value: 0.1523,
            width: 1,
            label: {
              text: 'Actual price',
              rotation: 90
            }
          }
        ],
        title: {
          text: 'Price'
        }
      },
      yAxis: [
        {
          max: 100,
          lineWidth: 1,
          gridLineWidth: 1,
          title: null,
          tickWidth: 1,
          tickLength: 5,
          tickPosition: 'inside',
          labels: {
            align: 'left',
            x: 8
          }
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
      plotOptions: {
        area: {
          fillOpacity: 0.2,
          lineWidth: 1,
          step: 'center'
        }
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

          color: '#03a7a8'
        }
      ]
    }
    function findActualPrice(bids, asks) {
      const maxBidPrice = bids[bids.length - 1][0]
      const minAskPrice = asks[0][0]
      const actualPrice = (maxBidPrice + minAskPrice) / 2
      return actualPrice
    }
    const chartOptions = ref({})
    onMounted(async () => {
      currenciesPairs.value = await getOrderBookCurreciesPairsAsync()
      selectedCurrencyPair.value = currenciesPairs.value[0]

      setInterval(drawChartAsync, 5000)
    })

    async function drawChartAsync() {
      if (selectedCurrencyPair.value.value) {
        const response = await getOrderBookAsync(selectedCurrencyPair.value.value)
        chartOptions.value = chartTemplate
        chartOptions.value.title.text = selectedCurrencyPair.value.view + staticText

        let bids = response.bids.reverse()

        let asks = response.asks

        chartOptions.value.series[1].data = bids
        chartOptions.value.series[0].data = asks
        const actualPrice = findActualPrice(bids, asks)
        chartOptions.value.xAxis.plotLines[0].value = actualPrice
        chartOptions.value.xAxis.max = actualPrice * 2
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
.select_currencies {
  margin-top: -100px;
}
</style>
