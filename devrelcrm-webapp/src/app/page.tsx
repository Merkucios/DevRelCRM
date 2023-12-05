import MaxWidthWrapper from "@/components/MaxWidthWrapper";
import MainInformation from "@/components/MainInformation";
import IntegrationsReel from "@/components/IntegrationsReel";
import React from "react";

export default function Home() {
  return (
    <MaxWidthWrapper>
      <MainInformation />
      <IntegrationsReel />
    </MaxWidthWrapper>
  );
}
