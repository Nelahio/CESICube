"use client";

import { Button, TextInput } from "flowbite-react";
import React, { useEffect } from "react";
import { FieldValues, useForm } from "react-hook-form";
import Input from "../components/Input";
import DateInput from "../components/DateInput";
import { createEnchere, updateEnchere } from "../actions/enchereActions";
import { usePathname, useRouter } from "next/navigation";
import toast from "react-hot-toast";
import { Enchere } from "@/types";

type Props = {
  enchere?: Enchere;
};

export default function EnchereForm({ enchere }: Props) {
  const router = useRouter();
  const pathName = usePathname();
  const {
    control,
    handleSubmit,
    setFocus,
    reset,
    formState: { isSubmitting, isValid },
  } = useForm({
    mode: "onTouched",
  });

  useEffect(() => {
    if (enchere) {
      const { make, productName, size, comments, year, color } = enchere;
      reset({ make, productName, size, comments, year, color });
    }
    setFocus("make");
  }, [setFocus]);

  async function onSubmit(data: FieldValues) {
    try {
      let id = "";
      let res;
      if (pathName === "/encheres/create") {
        res = await createEnchere(data);
        id = res.id;
      } else {
        if (enchere) {
          res = await updateEnchere(data, enchere.id);
          id = enchere.id;
        }
      }

      if (res.error) {
        throw res.error;
      }
      router.push(`/encheres/details/${id}`);
    } catch (error: any) {
      toast.error(error.status + " " + error.message);
    }
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
      {pathName === "/encheres/create" && (
        <>
          <div className="grid grid-cols-2 gap-3">
            <Input
              label="Prix de réserve (entrer 0 si pas de réserve)"
              name="reservePrice"
              control={control}
              type="number"
              rules={{ required: "Le prix de réserve est obligatoire" }}
            />
            <DateInput
              label="Date de fin d'enchère"
              name="auctionEnd"
              control={control}
              dateFormat={"dd MMMM yyyy h:mm a"}
              showTimeSelect
              rules={{ required: "La date de fin est obligatoire" }}
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
        </>
      )}
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
