import http from '@/api/http';

export async function getOrderBookCurreciesPairsAsync() {
  const { data } = await http.get(`/orderbook/currecies-pairs`);
  return data.data;
}

export async function getOrderBookAsync(curreciesPair) {
  const url = "/orderbook/"+curreciesPair;
  console.log(curreciesPair);
  const { data } = await http.get(url);
  return data.data;
}