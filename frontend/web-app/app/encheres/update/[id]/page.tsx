import React from "react";

export default function Update({ params }: { params: { id: string } }) {
  return <div>Mise à jour de {params.id}</div>;
}
