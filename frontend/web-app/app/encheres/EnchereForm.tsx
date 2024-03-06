"use client";

import { Button, TextInput } from "flowbite-react";
import React from "react";
import { FieldValues, useForm } from "react-hook-form";

export default function EnchereForm() {
  const {
    register,
    handleSubmit,
    setFocus,
    formState: { isSubmitting, isValid, isDirty, errors },
  } = useForm();

  function onSubmit(data: FieldValues) {
    console.log(data);
  }

  return (
    <form className="flex flex-col mt-3" onSubmit={handleSubmit(onSubmit)}>
      <div className="mb-3 block">
        <TextInput
          {...register("make", { required: "La marque est obligatoire" })}
          placeholder="Marque"
          color={errors?.make && "Erreur"}
          helperText={errors.make?.message as string}
        />
      </div>
      <div className="mb-3 block">
        <TextInput
          {...register("productName", { required: "Le nom est obligatoire" })}
          placeholder="Nom"
          color={errors?.productName && "Erreur"}
          helperText={errors.productName?.message as string}
        />
      </div>
      <div className="flex justify-between">
        <Button outline color="gray">
          Annuler
        </Button>
        <Button
          isProcessing={isSubmitting}
          disabled={!isValid}
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
