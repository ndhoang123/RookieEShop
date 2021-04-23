import React from "react";
import { productRes } from "../pages/config";

export default function ProductImage({ src, item }) {
  return (
    <div>
      {!src ? (
        <span className="text-secondary">No image</span>
      ) : (
        <img width={100} src={productRes + src} alt={`${item.name} Image`} />
      )}
    </div>
  );
}