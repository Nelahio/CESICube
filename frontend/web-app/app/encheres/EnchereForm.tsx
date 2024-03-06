"use client";

import { Button, TextInput } from "flowbite-react";
import React from "react";
import { FieldValues, useForm } from "react-hook-form";
import Input from "../components/Input";

export default function EnchereForm() {
  const {
    control,
    handleSubmit,
    setFocus,
    formState: { isSubmitting, isValid, isDirty, errors },
  } = useForm();

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
