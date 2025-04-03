import axios from "axios";
import { Card } from "../types/Card";

const API_URL = "http://localhost:5032/api/cards";

export const getCards = async (
  keyword: string = "",
  pageNumber: number = 1,
  pageSize: number = 20
): Promise<Card[]> => {
  try {
    const response = await axios.get(API_URL, {
      params: {
        keyword,
        pageNumber,
        pageSize
      }
    });

    return response.data;
  } catch (error) {
    console.error("Error fetching cards:", error);
    return [];
  }
};
