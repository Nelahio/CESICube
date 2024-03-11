"use server";

import { Enchere, PagedResult } from "@/types";
import { getTokenWorkaround } from "./authActions";
import { fetchWrapper } from "@/lib/fetchWrapper";
import { FieldValues } from "react-hook-form";
import { revalidatePath } from "next/cache";

export async function getData(query: string): Promise<PagedResult<Enchere>> {
  return await fetchWrapper.get(`recherche${query}`);
}

export async function updateEnchereTest() {
  const data = {
    size: Math.floor(Math.random() * 10000) + 1,
  };

  return await fetchWrapper.put(
    "encheres/47111973-d176-4feb-848d-0ea22641c31a",
    data
  );
}

export async function createEnchere(data: FieldValues) {
  return await fetchWrapper.post("encheres", data);
}

export async function getDetailedViewData(id: string): Promise<Enchere> {
  return await fetchWrapper.get(`encheres/${id}`);
}

export async function updateEnchere(data: FieldValues, id: string) {
  const res = await fetchWrapper.put(`encheres/${id}`, data);
  revalidatePath(`/encheres/${id}`);
  return res;
}

export async function deleteEnchere(id: string) {
  return await fetchWrapper.del(`encheres/${id}`);
}
