"use client";

import MaxWidthWrapper from "@/components/Main/MaxWidthWrapper";
import EmailForm from "@/components/Integrations/MessageService/EmailForm";
import { sendEmail } from "@/api/MessageSendingAPI";
import { EmailData } from "@/data/MessageSending/EmailData";
import { useState } from 'react';


export default function MessageSending() {
  return (
    <MaxWidthWrapper>
      <EmailForm />
    </MaxWidthWrapper>
  );
}
