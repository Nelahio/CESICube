"use client";

import { Button, TextInput } from "flowbite-react";
import React, { useEffect } from "react";
import { FieldValues, useForm } from "react-hook-form";
import Input from "../components/Input";

export default function EnchereForm() {
  const {
    control,
    handleSubmit,
    setFocus,
    formState: { isSubmitting, isValid, isDirty, errors },
  } = useForm({
    mode: "onTouched",
  });

  useEffect(() => {
    setFocus("make");
  }, [setFocus]);

  function onSubmit(data: FieldValues) {
    console.log(data);
  }

  return (
    <form className="flex flex-col mt-3" onSubmit={handleSubmit(onSubmit)}>
      <Input
        label="Marque"
        name="make"
        control={control}
        rules={{ required: "La marque est obligatoire" }}
      />
      <Input
        label="Nom"
        name="productName"
        control={control}
        rules={{ required: "Le nom est obligatoire" }}
      />
      <Input
        label="Couleur"
        name="color"
        control={control}
        rules={{ required: "La couleur est obligatoire" }}
      />
      <div className="grid grid-cols-2 gap-3">
        <Input
          label="Année"
          name="year"
          control={control}
          type="number"
          rules={{ required: "L'année est obligatoire" }}
        />
        <Input
          label="Taille/dimensions"
          name="size"
          control={control}
          type="number"
          rules={{ required: "Les dimensions sont obligatoires" }}
        />
      </div>
      <div className="grid grid-cols-2 gap-3">
        <Input
          label="Prix de réserve (entrer 0 si pas de réserve)"
          name="reservePrice"
          control={control}
          type="number"
          rules={{ required: "Le prix de réserve est obligatoire" }}
        />
        <Input
          label="Date de fin d'enchère"
          name="auctionEnd"
          control={control}
          type="date"
          rules={{ required: "La date est obligatoire" }}
        />
      </div>
      <Input
        label="Commentaires"
        name="comments"
        control={control}
        rules={{ required: "Les commentaires sont obligatoires" }}
      />
      <Input
        label="URL Image"
        name="imageUrl"
        control={control}
        rules={{ required: "L'URL de l'image est obligatoire" }}
      />
      <div className="flex justify-between">
        <Button outline color="gray">
          Annuler
        </Button>
        <Button
          isProcessing={isSubmitting}
          type="submit"
          outline
          color="success"
        >
          Envoyer
        </Button>
      </div>
    </form>
  );
}
