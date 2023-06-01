import axios from "axios";

const service1Axios = axios.create({
  baseURL: "https://localhost:7163/api/",
});

const responseBody = (response) => response.data;

const requests = {
  get: (url) => service1Axios.get(url).then(responseBody),
  post: (url, body) => service1Axios.post(url, body).then(responseBody),
  put: (url, body) => service1Axios.put(url, body).then(responseBody),
  del: (url) => service1Axios.delete(url).then(responseBody),
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
  create: (values) => requests.post("Stripe/customer/add", values),
};

const agent = {
  TypeOfPayments,
  Payment,
  Payments,
  Customers,
};

export default agent;
