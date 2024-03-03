import React from "react";
import EnchereCard from "./EnchereCard";
import { log } from "console";
import { Enchere, PagedResult } from "@/types";
import AppPagination from "../components/AppPagination";

async function getData(): Promise<PagedResult<Enchere>> {
  const res = await fetch("http://localhost:6001/recherche?pageSize=4");

  if (!res.ok) throw new Error("Erreur lors de la récupération des données");

  return res.json();
}

export default async function Listings() {
  const data = await getData();
  return (
    <>
      <div className="grid grid-cols-4 gap-6">
        {data &&
          data.results.map((enchere) => {
            return <EnchereCard enchere={enchere} key={enchere.id} />;
          })}
      </div>
      <div className="flex justify-center mt-4">
        <AppPagination currentPage={1} pageCount={data.pageCount} />
      </div>
    </>
  );
}
