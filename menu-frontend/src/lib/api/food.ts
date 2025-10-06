// src/api/food.ts
import axios from "axios";

const BASE_URL = "http://localhost:5084/Food";

// --- Types that match your backend models ---
export interface Category {
  id: number;
  name: string;
}

export interface Food {
  id: number;
  name: string;
  price: number;
  categoryId: number;
  category?: Category;
}

export interface AddFoodDto {
  name: string;
  price: number;
  categoryId: number;
}

// --- API functions ---
export async function getAllFoods(): Promise<Food[]> {
  const response = await axios.get<Food[]>(BASE_URL);
  return response.data;
}

export async function getFoodById(id: number): Promise<Food> {
  const response = await axios.get<Food>(`${BASE_URL}/${id}`);
  return response.data;
}

export async function addFood(food: AddFoodDto): Promise<Food> {
  const response = await axios.post<Food>(BASE_URL, food, {
    headers: { "Content-Type": "application/json" },
  });
  return response.data;
}
