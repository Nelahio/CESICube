import { getDetailedViewData } from "@/app/actions/enchereActions";
import Heading from "@/app/components/Heading";
import React from "react";
import CountdownTimer from "../../CountdownTimer";
import EnchereImage from "../../EnchereImage";
import DetailedSpecs from "./DetailedSpecs";

export default async function Details({ params }: { params: { id: string } }) {
  const data = await getDetailedViewData(params.id);
  return <div>
    <div className="flex justify-between">
      <Heading title={`${data.make} ${data.productName}`} />
      <div className="flex gap-3">
        <h3 className="text-2xl font-semibold">Temps restant :</h3>
        <CountdownTimer auctionEnd={data.auctionEnd} />
      </div>
    </div>

    <div className="grid grid-cols-2 gap-6 mt-3">
      <div className="w-full bg-gray-200 aspect-h-10 aspect-w-16 rounded-lg overflow-hidden">
        <EnchereImage imageUrl={data.imageUrl} />
      </div>
      <div className="border-2 rounded-lg p-2 bg-gray-100">
        <Heading title="Bids" />
      </div>
    </div>
    <div className="mt-3 grid grid-cols-1 rounded-lg">
      <DetailedSpecs enchere={data} />
    </div>
  </div>;
}
