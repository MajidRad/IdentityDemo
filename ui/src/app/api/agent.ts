import axios, { AxiosError, AxiosRequestConfig, AxiosResponse } from "axios";
import { toast } from "react-toastify";

import { store } from "../store/configureStore";

axios.defaults.baseURL = "http://localhost:5000/api/";
const responseBody = <T>(response: AxiosResponse<T>) => response.data;

axios.interceptors.request.use((config: AxiosRequestConfig) => {
  const token = store.getState().account.User?.token;
  if (token) config.headers!.Authorization = `Bearer ${token}`;
  return config;
});

axios.interceptors.response.use(
  (response) => {
    return response;
  },
  (error: AxiosError) => {
    // console.log("catch by interceptors");
    const { data, status } = error.response!;

    switch (status) {
      case 400:
        if (data.errors) {
          const modelStateErrors: string[] = [];
          for (const key in data.errors) {
            if (data.errors[key]) modelStateErrors.push(data.errors[key]);
          }
          throw modelStateErrors.flat();
        }
        toast.error(data.title);
        break;
      case 401:
        toast.error(data.title || "unauthorized");
        break;
      case 404:
        toast.error(data.title);
        break;
      case 500:
        toast.error(data.title || "server Error");
        break;
      default:
        break;
    }
    return Promise.reject(error.response);
  }
);

const requests = {
  get: (url: string, params?: URLSearchParams) =>
    axios.get(url, { params }).then(responseBody),
  post: (url: string, body: {}) => axios.post(url, body).then(responseBody),
  put: (url: string, body: {}) => axios.put(url, body).then(responseBody),
  delete: (url: string) => axios.delete(url).then(responseBody),
};

const Cars = {
  getCars: () => requests.get("Car/GetCars"),
  getFilteredCars: () => requests.get("Car/GetFilteredCar"),
  getCar: (Id: number) => requests.get(`Car/GetCar/${Id}`),
};

const Brands = {
  getBrands: (params?: URLSearchParams) =>
    requests.get("Brand/GetBrands", params),
};

const Account = {
  login: (values: any) => requests.post("Account/login", values),
  register: (values: any) => requests.post("account/register", values),
  currentUser: () => requests.get("account/currentUser"),
  fetchAddress: () => requests.get("account/"),
};

const agent = {
  Account,
  Brands,
  Cars,
};

export default agent;
