import MaxWidthWrapper from "@/components/Main/MaxWidthWrapper";
import MainInformation from "@/components/Main/MainInformation";
import IntegrationsReel from "@/components/Main/IntegrationsReel";
import React from "react";

export default function Home() {
  return (
    <MaxWidthWrapper>
      <MainInformation />
      <IntegrationsReel />
    </MaxWidthWrapper>
  );
}
