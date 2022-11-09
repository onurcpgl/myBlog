import axios from "axios";

export const httpService =  axios.create({
  baseURL: `https://localhost:7229/`
});