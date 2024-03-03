"use client";

import { useParamsStore } from "@/hooks/useParamsStore";
import React from "react";
import { GiDelicatePerfume } from "react-icons/gi";

export default function Logo() {
  const reset = useParamsStore((state) => state.reset);
  return (
    <div
      onClick={reset}
      className="cursor-pointer flex items-center gap-2 text-3xl font-semibold text-red-500"
    >
      <GiDelicatePerfume size={34} />
      <div>CESI Enchères</div>
    </div>
  );
}
