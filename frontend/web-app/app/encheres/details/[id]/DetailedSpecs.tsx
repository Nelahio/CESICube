'use client';

import { Enchere } from "@/types";
import { Table } from "flowbite-react";

type Props = {
    enchere: Enchere
}
export default function DetailedSpecs({ enchere }: Props) {
    return (
        <Table striped={true}>
            <Table.Body className="divide-y">
                <Table.Row className="bg-white dark:border-gray-700 dark:bg-gray-800">
                    <Table.Cell className="whitespace-nowrap font-medium text-gray-900 dark:text-white">
                        Vendeur
                    </Table.Cell>
                    <Table.Cell>
                        {enchere.seller}
                    </Table.Cell>
                </Table.Row>
                <Table.Row className="bg-white dark:border-gray-700 dark:bg-gray-800">
                    <Table.Cell className="whitespace-nowrap font-medium text-gray-900 dark:text-white">
                        Marque
                    </Table.Cell>
                    <Table.Cell>
                        {enchere.make}
                    </Table.Cell>
                </Table.Row>
                <Table.Row className="bg-white dark:border-gray-700 dark:bg-gray-800">
                    <Table.Cell className="whitespace-nowrap font-medium text-gray-900 dark:text-white">
                        Nom
                    </Table.Cell>
                    <Table.Cell>
                        {enchere.productName}
                    </Table.Cell>
                </Table.Row>
                <Table.Row className="bg-white dark:border-gray-700 dark:bg-gray-800">
                    <Table.Cell className="whitespace-nowrap font-medium text-gray-900 dark:text-white">
                        Année de fabrication
                    </Table.Cell>
                    <Table.Cell>
                        {enchere.year}
                    </Table.Cell>
                </Table.Row>
                <Table.Row className="bg-white dark:border-gray-700 dark:bg-gray-800">
                    <Table.Cell className="whitespace-nowrap font-medium text-gray-900 dark:text-white">
                        Taille
                    </Table.Cell>
                    <Table.Cell>
                        {enchere.size}
                    </Table.Cell>
                </Table.Row>
                <Table.Row className="bg-white dark:border-gray-700 dark:bg-gray-800">
                    <Table.Cell className="whitespace-nowrap font-medium text-gray-900 dark:text-white">
                        Possède un prix de réserve ?
                    </Table.Cell>
                    <Table.Cell>
                        {enchere.reservePrice > 0 ? 'Oui' : 'Non'}
                    </Table.Cell>
                </Table.Row>
            </Table.Body>
        </Table>
    );
}