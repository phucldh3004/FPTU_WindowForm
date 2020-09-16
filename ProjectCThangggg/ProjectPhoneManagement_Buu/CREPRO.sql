Use PhoneMangement

-------
go
create proc [FindPhone9](@Filter9 varchar(50))
as
begin
select * from Phone
where PhoneName like '%'+@Filter9+'%'

end
----------------

go
create proc [FindCust10](@Filter10 varchar(50))
as
begin
Select FullName, DayofBirth, Address, Email, PhoneNumber, PhoneID, PhoneName, Pirce, InvoiceDetails.Quantity
FROM Customer, Phone, InvoiceDetails, Invoice 
WHERE InvoiceDetails.Invoice_ID = Invoice.ID and Invoice.CustomerPhone = Customer.Phonenumber and InvoiceDetails.PhoneID = Phone.ID
and PhoneNumber like '%'+@Filter10+'%'
end
