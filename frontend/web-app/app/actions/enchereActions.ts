"use server";

import { Enchere, PagedResult } from "@/types";
import { getTokenWorkaround } from "./authActions";
import { fetchWrapper } from "@/lib/fetchWrapper";

export async function getData(query: string): Promise<PagedResult<Enchere>> {
  return await fetchWrapper.get(`recherche${query}`);
}

export async function UpdateEnchereTest() {
  const data = {
    size: Math.floor(Math.random() * 10000) + 1,
  };

  const token = await getTokenWorkaround();

  const res = await fetch(
    "http://localhost:6001/encheres/47111973-d176-4feb-848d-0ea22641c31a",
    {
      method: "PUT",
      headers: {
        "Content-type": "application/json",
        Authorization: "Bearer " + token?.access_token,
      },
      body: JSON.stringify(data),
    }
  );

  if (!res.ok) return { status: res.status, message: res.statusText };

  return res.statusText;
}
