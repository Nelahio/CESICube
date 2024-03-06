import Heading from "@/app/components/Heading";
import React from "react";
import EnchereForm from "../EnchereForm";

export default function Create() {
  return (
    <div className="mx-auto max-w-[75%] shadow-lg p-10 bg-white rounded-lg">
      <Heading
        title="Vendre un produit"
        subtitle="Saisissez les détails de votre produit"
      />
      <EnchereForm />
    </div>
  );
}
