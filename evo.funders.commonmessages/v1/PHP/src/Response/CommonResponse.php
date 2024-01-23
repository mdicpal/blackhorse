<?php

namespace AzureFunderCommonMessages\PHP\Response;

use AzureFunderCommonMessages\PHP\Traits\JsonSerializer;
use AzureFunderCommonMessages\PHP\Models\{FunderReference, RawData};

class CommonResponse implements \JsonSerializable
{
	use JsonSerializer;

	private ?int $version = 1;
	private ?string $responseType;
	private ?int $quoteId;
	private ?string $funderCode;
	private ?FunderReference $funderReference;
	private ?Response $response;
	/** @var RawData[]|null */
	private array $rawData;

	/**
	 * @return int|null
	 */
	public function getVersion(): ?int
	{
		return $this->version;
	}

	/**
	 * @param int $version
	 * @return CommonResponse
	 */
	public function setVersion(int $version): CommonResponse
	{
		$this->version = $version;
		return $this;
	}

	/**
	 * @return string|null
	 */
	public function getResponseType(): ?string
	{
		return $this->responseType;
	}

	/**
	 * @param string $responseType
	 * @return CommonResponse
	 */
	public function setResponseType(string $responseType): CommonResponse
	{
		$this->responseType = $responseType;
		return $this;
	}

	/**
	 * @return int|null
	 */
	public function getQuoteId(): ?int
	{
		return $this->quoteId;
	}

	/**
	 * @param int $quoteId
	 * @return CommonResponse
	 */
	public function setQuoteId(int $quoteId): CommonResponse
	{
		$this->quoteId = $quoteId;
		return $this;
	}

	/**
	 * @return string|null
	 */
	public function getFunderCode(): ?string
	{
		return $this->funderCode;
	}

	/**
	 * @param string $funderCode
	 * @return CommonResponse
	 */
	public function setFunderCode(string $funderCode): CommonResponse
	{
		$this->funderCode = $funderCode;
		return $this;
	}

	/**
	 * @return FunderReference|null
	 */
	public function getFunderReference(): ?FunderReference
	{
		return $this->funderReference;
	}

	/**
	 * @param FunderReference|null $funderReference
	 * @return CommonResponse
	 */
	public function setFunderReference(?FunderReference $funderReference): CommonResponse
	{
		$this->funderReference = $funderReference;
		return $this;
	}

	/**
	 * @return Response|null
	 */
	public function getResponse(): ?Response
	{
		return $this->response;
	}

	/**
	 * @param Response|null $response
	 * @return CommonResponse
	 */
	public function setResponse(?Response $response): CommonResponse
	{
		$this->response = $response;
		return $this;
	}

	/**
	 * @return RawData[]|null
	 */
	public function getRawData(): ?array
	{
		return $this->rawData;
	}

	/**
	 * @param RawData[] $rawData
	 * @return CommonResponse
	 */
	public function setRawData(array $rawData = []): CommonResponse
	{
		$this->rawData = $rawData;
		return $this;
	}

	public static function fromJson(array $data): self
	{
		$instance = new self();
		$instance->version = $data['version'];
		$instance->responseType = $data['responseType'];
		$instance->quoteId = $data['quoteId'];
		$instance->funderCode = $data['funderCode'];
		$instance->funderReference = ($data['funderReference'] ?? null) !== null ? FunderReference::fromJson($data['funderReference']) : null;
		$namespace = __NAMESPACE__ . "\\";
		$class = class_exists($namespace . $instance->responseType) ? $namespace . $instance->responseType : "{$namespace}Response";
		if ($data['response']) {
			$instance->response = $class::fromJson($data['response']);
		}
		$instance->rawData = ($data['rawData'] ?? null) !== null ? array_map(static function ($data) {
			return RawData::fromJson($data);
		}, $data['rawData']) : [];
		return $instance;
	}
	public static function fromJsonString(string $input): CommonResponse {
		return self::fromJson(json_decode($input, true));
	}
}