import axios from "axios";

axios.defaults.baseURL = "https://localhost:7163/api/";

const responseBody = (response) => response.data;

const requests = {
  get: (url) => axios.get(url).then(responseBody),
  post: (url, body) => axios.post(url, body).then(responseBody),
  put: (url, body) => axios.put(url, body).then(responseBody),
  del: (url) => axios.delete(url).then(responseBody),
};

const TypeOfPayments = {
  get: (sortBy, searchString) =>
    requests.get("TypeOfPayment/type-of-payments", { sortBy, searchString }),
};

const Payment = {
  create: (values) => requests.post("Stripe/payment/add", values),
};

const Payments = {
  get: () => requests.get("Stripe/payments"),
};

const Customers = {
  get: () => requests.get("Stripe/customers"),
};

const agent = {
  TypeOfPayments,
  Payment,
  Payments,
  Customers,
};

export default agent;
