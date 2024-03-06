"use server";

import { Enchere, PagedResult } from "@/types";
import { getTokenWorkaround } from "./authActions";

export async function getData(query: string): Promise<PagedResult<Enchere>> {
  const res = await fetch(`http://localhost:6001/recherche${query}`);

  if (!res.ok) throw new Error("Erreur lors de la récupération des données");

  return res.json();
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
